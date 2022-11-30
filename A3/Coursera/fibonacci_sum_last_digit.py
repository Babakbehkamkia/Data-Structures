# Uses python3
import sys


def get_fibonacci_huge_naive(n, m):
    fib_list=[0,1,1]

    count=0
    for i in range(3,n+1):
        fib_list.append((fib_list[i-1]+fib_list[i-2])%m)
        if fib_list[-1]==1 and fib_list[-2]==0 :
            count+=1
            break

    if count==0:
        return fib_list[-1]

    return fib_list[n%(len(fib_list)-2)]


def fibonacci_sum_naive(n):
    answer=get_fibonacci_huge_naive(n+2,10)-1
    if answer==-1:
        return 9
    return answer

if __name__ == '__main__':
    # input = sys.stdin.read()
    n = int(input())
    print(fibonacci_sum_naive(n))
