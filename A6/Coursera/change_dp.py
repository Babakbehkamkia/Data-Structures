# Uses python3
import sys

def get_change(m):
    #write your code here
    
    # a=m // 4
    # result+=a-1
    # if m%4==0:
    #     result+=1
    # else:
    #     result+=2
    d=[]
    for i in range(m+1):
        d.append(0)
    n=1
    while n<=m:
        first=d[n-1]+1
        second=first
        third=first
        if n>=3:
            second=d[n-3]+1
        if n>=4:
            third=d[n-4]+1
        
        
        d[n]=min(first,second,third)
        n+=1


    return d[n-1]


if __name__ == '__main__':
    m = int(sys.stdin.read())
    print(get_change(m))
# print(get_change(10))
