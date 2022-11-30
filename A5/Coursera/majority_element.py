# Uses python3
import sys
import random


# def mergesort(n,a):
#     if n==1:
#         return a

#     a1=[]
#     a2=[]
#     for item in range(int(n/2)):

#         a1.append(a[item])

#     m=int(n/2)
#     for item2 in range(int(n/2),n):

#         a2.append(a[item2])

#     b1=mergesort(int(n/2),a1)
#     b2=mergesort((n-int(n/2)),a2)
#     result=[]


#     first=0
#     second=0
#     # k=0
#     for k in range(n):

#         if first>=len(b1) :
#             first=-1
#             break
#         if second>=len(b2) :

#             second=-1
#             break

#         if b1[first]>=b2[second]:
#             result.append(b2[second])
#             second+=1
#         else:

#             result.append(b1[first])
#             first+=1

#     if first==-1:
#         for j in range (second,len(b2)):
#             result.append(b2[j])
#             k+=1
#     if second==-1:
#         for i in range(first,len(b1)):
#             result.append(b1[i])
#             k+=1

#     return result



def partition3(a, l, r):
    #write your code here
    x = a[l]
    j = l
    for i in range(l + 1, r + 1):
        if a[i] <= x:
            j += 1
            a[i], a[j] = a[j], a[i]
    k=inverse_partition3(a,l,j)
    # a[l], a[k] = a[k], a[l]
    
    return k,j

def inverse_partition3(a,l,r):
    x = a[l]
    j = l
    for i in range(l + 1, r + 1):
        if a[i] < x:
            j += 1
            a[i], a[j] = a[j], a[i]
    a[l], a[j] = a[j], a[l]
    return j


def randomized_quick_sort(a, l, r):
    if l >= r:
        return
    k = random.randint(l, r)
    a[l], a[k] = a[k], a[l]
    #use partition3
    m,n = partition3(a, l, r)
    randomized_quick_sort(a, l, m - 1)
    randomized_quick_sort(a, n + 1, r)


def get_majority_element(a, left, right):
    # if left == right:
    #     return -1
    # if left + 1 == right:
    #     return a[left]
    # #write your code here
    # return -1 
    randomized_quick_sort(a, left, right-1)
    count=1
    max=0
    for index in range (len(a)-1):
        if a[index]==a[index+1]:
            count+=1
        
        else:
            if max<count:
                max=count
            count=1
    # print(a)
    # print(max)
    if max<count:
        max=count
    if max>(len(a))/2:
        return 1
    else :
        return -1

# def get_majority_element(a, left, right):
#     max_item=max(a)
#     bit_list=[]
#     for i in range(max_item+1):
#         bit_list.append(0)
#     for j in range(len(a)):
#         bit_list[a[j]]+=1
#     for k in range(len(bit_list)):
#         if bit_list[k]>(len(a)/2):
#             return 1
#     return -1



if __name__ == '__main__':
    input = sys.stdin.read()
    n, *a = list(map(int, input.split()))
    if get_majority_element(a, 0, n) != -1:
        print(1)
    else:
        print(0)


# print(get_majority_element([2,3,9,2,2], 0, 5))