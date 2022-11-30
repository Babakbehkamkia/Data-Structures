# Uses python3
import sys

def binary_search2(a, x):
    answer=-1
    left, right = 0, len(a)
    
    # write your code here
    while right-left!=1 or left==0:
        avrage=int((right+left)/2)
        if a[avrage]==x :

            answer=avrage
            break

        if a[avrage]>x:

            right=avrage

        
        else:

            left=avrage

    return answer



def binary_search(a, x,left,right):
    if left>right :
        return -1
    mid = int((left+right)/2)
    if a[mid]>x:
        return binary_search(a,x,left,mid-1)
    elif a[mid]<x:
        return binary_search(a,x,mid+1,right)
    else:
        return mid






def linear_search(a, x):
    for i in range(len(a)):
        if a[i] == x:
            return i
    return -1

if __name__ == '__main__':
    input = sys.stdin.read()
    data = list(map(int, input.split()))
    n = data[0]
    m = data[n + 1]
    a = data[1 : n + 1]
    for x in data[n + 2:]:
        # replace with the call to binary_search when implemented
        print(binary_search(a, x,0,len(a)-1), end = ' ')
# for x in [1 ,2, 3, 4 ,5]:
#     print(binary_search([1 ,2, 3, 4 ,5], x,0,4), end = ' ')

