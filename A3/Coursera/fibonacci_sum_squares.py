# Uses python3
from sys import stdin

# def get_fibonacci_last_digit_naive(n):
#     if n <= 1:
#         return n

#     previous = 0
#     current  = 1

#     for _ in range(n-1 ):
#         previous, current = current, previous + current

#     return current % 10


def get_fibonacci_huge_naive(n, m):
    fib_list=[0,1]
    if n<=0:
        return 0
    if n==1 :
        return 1
    count=0
    for i in range(2,n+1):
        fib_list.append((fib_list[i-1]+fib_list[i-2])%m)
        if fib_list[-1]==1 and fib_list[-2]==0 :
            count+=1
            break
    
    if count==0:
        return fib_list[-1]

    return fib_list[n%(len(fib_list)-2)]

def fibonacci_sum_squares_naive(n):
    current=get_fibonacci_huge_naive(n,10)
    previous=get_fibonacci_huge_naive(n-1,10)
    sum=(current+previous)*current

    return sum % 10

if __name__ == '__main__':
    n = int(stdin.read())
    print(fibonacci_sum_squares_naive(n))
    
