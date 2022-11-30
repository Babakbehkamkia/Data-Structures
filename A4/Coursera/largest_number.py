#Uses python3

import sys

def largest_number(a):
    b=[]
    for i in a:
        b.append(i)
    largest_lenght=0
    for i in a:
        if largest_lenght<len(i):
            largest_lenght=len(i)
    for i in range(len(a)):
        while largest_lenght>=len(a[i]):
            for j in range(len(a[i])):
                a[i]+=a[i][j]
                if largest_lenght+1==len(a[i]):
                    break
        
    
    #write your code here
    res = ""
    for j in range(len(a)):
        max_item=max(a)
        max_index=a.index(max_item)
        res += b[max_index]
        b.remove(b[max_index])
        a.remove(max_item)
    return res

if __name__ == '__main__':
    input = sys.stdin.read()
    data = input.split()
    a = data[1:]
    # a=data
    print(largest_number(a))
    
