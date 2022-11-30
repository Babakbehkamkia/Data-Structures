# Uses python3
import sys
import random

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


def binary_search_s(a, x,left,right):
    if right<0 :
        return -1
    if left>right:
        return right
    mid = int((left+right)/2)
    if a[mid]>x:
        if a[mid-1]<x:
            return mid-1
        else:
            return binary_search_s(a,x,left,mid-1)
    elif a[mid]<x:
        return binary_search_s(a,x,mid+1,right)
    else:
        while mid+1<len(a):
            if a[mid]==a[mid+1]:
                mid+=1
            else:
                break
        return mid

def binary_search_f(a, x,left,right):
    if right<0 :
        return -1
    if left>right:
        return right
    mid = int((left+right)/2)
    if a[mid]>x:
        if a[mid-1]<x:
            return mid-1
        else:
            return binary_search_f(a,x,left,mid-1)
    elif a[mid]<x:
        return binary_search_f(a,x,mid+1,right)
    else:
        while mid-1>=0:
            if a[mid]==a[mid-1]:
                mid-=1
            else:
                break
        return mid-1



def fast_count_segments(starts, ends, points):
    cnt = [0] * (len(points))
    randomized_quick_sort(starts,0,len(starts)-1)
    randomized_quick_sort(ends,0,len(ends)-1)
    for p in range(len(points)):
        s=binary_search_s(starts,points[p],0,len(starts)-1)
        e=binary_search_f(ends,points[p],0,len(ends)-1)
        result=s-e
        if result<0:
            cnt[p]=0
        else:
            cnt[p]=result
    return cnt



# def fast_count_segments(starts, ends, points):
#     cnt = [0] * (ends[-1]+1-starts[0])
#     #write your code here
#     for i in range(len(starts)):
#         j=starts[i]
#         while j<=ends[i]:
#             cnt[j]+=1
#             j+=1
#     return cnt

def naive_count_segments(starts, ends, points):
    cnt = [0] * len(points)
    for i in range(len(points)):
        for j in range(len(starts)):
            if starts[j] <= points[i] <= ends[j]:
                cnt[i] += 1
    return cnt

if __name__ == '__main__':
    input = sys.stdin.read()
    data = list(map(int, input.split()))
    n = data[0]
    m = data[1]
    starts = data[2:2 * n + 2:2]
    ends   = data[3:2 * n + 2:2]
    points = data[2 * n + 2:]
    #use fast_count_segments
    cnt = fast_count_segments(starts, ends, points)
    for x in cnt:
        print(x, end=' ')
    # max_ends=max(ends)
    # min_starts=min(starts)
    # for x in points:
    #     if x>max_ends or x<min_starts:
    #         print(0,end=' ')
    #     else:
    #         print(cnt[x], end=' ')


# fast_count_segments([0,7], [5,10], [1,6,11])
# cnt = fast_count_segments([1,2,3,4], [5,5,5,5], [0,1,2,3,4,5])
# for x in cnt:
#     print(x, end=' ')
