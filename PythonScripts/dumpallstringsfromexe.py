import re

def extract_valid_ascii_strings(file_path, output_path, encoding='utf-8', min_length=3):
    valid_strings = []
    ascii_alpha = re.compile(r'^[A-Za-z_]+$')

    with open(file_path, 'rb') as f:
        buffer = bytearray()
        while byte := f.read(1):
            if byte == b'\x00':
                if len(buffer) >= min_length:
                    try:
                        decoded = buffer.decode(encoding)
                        if ascii_alpha.match(decoded):
                            valid_strings.append(decoded)
                    except UnicodeDecodeError:
                        pass  # skip bytes that can't be decoded
                buffer.clear()
            else:
                buffer.append(byte[0])

    # Save results to file
    with open(output_path, 'w', encoding='utf-8') as out_file:
        for i, s in enumerate(valid_strings, 1):
            out_file.write(f"{i}: {s}\n")



# Example usage
if __name__ == "__main__":
    path = "F:\\EAGames\\EA SPORTS FC 25\\FC25.exe"
    output_path = "extracted_strings.txt"
    extract_valid_ascii_strings(path, output_path)
