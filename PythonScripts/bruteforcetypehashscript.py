import hashlib
import struct

def sha256_last4_uint32_be(input_str):
    digest = hashlib.sha256(input_str.encode('utf-8')).digest()
    return struct.unpack('>I', digest[28:32])[0]

target_str = "AttribSchema_gp_actor_facialanim"
desired_hash = 2082094922  # 0x7C23642A

for seed in range(0, 1000000):  # Adjust range as needed
    combo = (target_str + str(seed)).lower()
    hash_val = sha256_last4_uint32_be(combo)
    
    if hash_val == desired_hash:
        print(f"Match found! Seed: {seed}")
        break
else:
    print("No match found within range.")