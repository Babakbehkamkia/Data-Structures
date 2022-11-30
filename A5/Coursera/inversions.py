# Uses python3
import sys


def mergesort(n,a):
    number_of_inversions = 0
    if n==1:
        return a,number_of_inversions

    a1=[]
    a2=[]
    for item in range(int(n/2)):

        a1.append(a[item])

    m=int(n/2)
    for item2 in range(int(n/2),n):

        a2.append(a[item2])
    number_to_add=0
    b1,number_to_add=mergesort(int(n/2),a1)
    number_of_inversions +=number_to_add
    b2,number_to_add=mergesort((n-int(n/2)),a2)
    number_of_inversions +=number_to_add
    result=[]


    first=0
    second=0
    # k=0
    for k in range(n):

        if first>=len(b1) :
            first=-1
            break
        if second>=len(b2) :

            second=-1
            break

        if b1[first]>b2[second]:
            result.append(b2[second])
            second+=1
            # number_of_inversions+=1
        else:

            result.append(b1[first])
            number_of_inversions+=len(result)-1-first
            first+=1

    if first==-1:
        for j in range (second,len(b2)):
            result.append(b2[j])
            
    if second==-1:
        for i in range(first,len(b1)):
            result.append(b1[i])
            number_of_inversions +=len(result)-1-i

    return result,number_of_inversions






def get_number_of_inversions(a, b, left, right):
    number_of_inversions = 0
    sorted_list=[]
    sorted_list,number_of_inversions= mergesort(right-left,a)
    
    # if right - left <= 1:
    #     return number_of_inversions
    # ave = (left + right) // 2
    # number_of_inversions += get_number_of_inversions(a, b, left, ave)
    # number_of_inversions += get_number_of_inversions(a, b, ave, right)
    #write your code here
    return number_of_inversions






# def get_number_of_inversions(a, b, left, right):
#     number_of_inversions = 0
#     if right - left <= 1:
#         return number_of_inversions
#     ave = (left + right) // 2
#     number_of_inversions += get_number_of_inversions(a, b, left, ave)
#     number_of_inversions += get_number_of_inversions(a, b, ave, right)
#     #write your code here
#     return number_of_inversions




# def get_number_of_inversions(a, b, left, right):
#     number_of_inversions = 0
#     if right - left <= 1:
#         return number_of_inversions
#     # a1=[]
#     # a2=[]
#     # for item in range(int(n/2)):

#     #     a1.append(a[item])

#     # m=int(n/2)
#     # for item2 in range(int(n/2),n):

#     #     a2.append(a[item2])

#     # b1=mergesort(int(n/2),a1)
#     # b2=mergesort((n-int(n/2)),a2)
#     # result=[]

#     ave = (left + right) // 2
#     number_of_inversions += get_number_of_inversions(a, b, left, ave)
#     number_of_inversions += get_number_of_inversions(a, b, ave, right)




#     first=left
#     second=ave
#     indexer=left
#     # k=0
#     for k in range(right-left):

#         if first==ave :
#             first=-1
#             break
#         if second==right :

#             second=-1
#             break

#         if a[first]>a[second]:
#             b[indexer]=(a[second])
#             second+=1
#             indexer+=1
#             number_of_inversions+=1
#         else:

#             b[indexer]=(a[first])
#             first+=1
#             indexer+=1

#     if first==-1:
#         for j in range (second,right):
#             b[indexer]=(a[j])
#             indexer+=1
#             # k+=1
#     if second==-1:
#         for i in range(first,ave):
#             b[indexer]=(a[i])
#             indexer+=1
#             # k+=1

#     return number_of_inversions








if __name__ == '__main__':
    input = sys.stdin.read()
    n, *a = list(map(int, input.split()))
    b = n * [0]
    print(get_number_of_inversions(a, b, 0, len(a)))


# print(get_number_of_inversions([2,3,9,2,9], [0,0,0,0,0], 0, 5))
