# Uses python3
import sys

def gcd_naive(a, b):
    if b==0:
        return a
    if b>a:
        (a,b)=(b,a)
    return gcd_naive(b , a % b)
def lcm_naive(a, b):
    
    return int(a*b/gcd_naive(a,b))

if __name__ == '__main__':
    # input = sys.stdin.read()
    a, b = map(int, input().split())
    print(lcm_naive(a, b))

