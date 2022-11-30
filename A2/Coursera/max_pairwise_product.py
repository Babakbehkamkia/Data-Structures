# python3


def max_pairwise_product(numbers):
    n = len(numbers)
    max_product1 = 0
    max_product2=0
    for i in range(n):
        if max_product1<numbers[i]:
            max_product1=numbers[i]
    numbers.remove(max_product1)
    for i in range(n-1):
        if max_product2<numbers[i]:
            max_product2=numbers[i]
            
    return max_product1*max_product2


if __name__ == '__main__':
    input_n=int(input())
    input_numbers = [int(x) for x in input().split()]
    print(max_pairwise_product(input_numbers))
