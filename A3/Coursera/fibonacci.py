# Uses python3
def calc_fib(n):
    fib_list=[0,1]
    for i in range(2,n+1):
        fib_list.append(fib_list[i-1]+fib_list[i-2])
    if n==0:
        return fib_list[0]
    return fib_list[-1]

n = int(input())
print(calc_fib(n))
