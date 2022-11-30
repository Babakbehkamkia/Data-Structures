# Uses python3
import sys

def get_change(m):
    count=0
    for i in [10,5,1]:
        while m-i>=0:
            m-=i
            count+=1

    #write your code here
    return count

if __name__ == '__main__':
    m = int(sys.stdin.read())
    # m=int(input())
    print(get_change(m))
