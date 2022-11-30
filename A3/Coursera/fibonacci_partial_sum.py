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

def fibonacci_partial_sum_naive(from_, to):
    sum=get_fibonacci_huge_naive(to+2,10)-get_fibonacci_huge_naive(from_+1,10)

    return sum % 10


# if __name__ == '__main__':
#     input = sys.stdin.read()
#     from_, to = map(int, input.split())
print(fibonacci_partial_sum_naive(150482468097531 ,479))