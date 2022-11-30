#Uses python3
import sys
import math
import random

# sorting

def partition3(a, l, r,index):
    #write your code here
    x = a[l][index]
    j = l
    for i in range(l + 1, r + 1):
        if a[i][index] <= x:
            j += 1
            a[i], a[j] = a[j], a[i]
    k=inverse_partition3(a,l,j,index)
    # a[l], a[k] = a[k], a[l]
    
    return k,j

def inverse_partition3(a,l,r,index):
    x = a[l][index]
    j = l
    for i in range(l + 1, r + 1):
        if a[i][index] < x:
            j += 1
            a[i], a[j] = a[j], a[i]
    a[l], a[j] = a[j], a[l]
    return j


def randomized_quick_sort(a, l, r,index):
    if l >= r:
        return
    k = random.randint(l, r)
    a[l], a[k] = a[k], a[l]
    #use partition3
    m,n = partition3(a, l, r,index)
    randomized_quick_sort(a, l, m - 1,index)
    randomized_quick_sort(a, n + 1, r,index)


def minimum_distance_y(my_list,d):
    randomized_quick_sort(my_list, 0, len(my_list)-1,1)
    for i in range(len(my_list)-1):
        max_index=i+7
        if len(my_list)<i+7:
            max_index=len(my_list)
        
        for j in range (i+1,max_index):
            distance=((my_list[i][0]-my_list[j][0])**2+(my_list[i][1]-my_list[j][1])**2)**0.5
            if distance<d:
                d=distance
    return d

# def minimum_distance_y(my_list,d):
#     for i in range(len(my_list)-1):
#         for j in range(i+1,len(my_list)):
#             distance=((my_list[i][0]-my_list[j][0])**2+(my_list[i][1]-my_list[j][1])**2)**0.5
#             if distance<d:
#                 d=distance
#     return d
    






def minimum_distance(my_list):
    #write your code here
    # return 10 ** 18
    if len(my_list)==3:
        distanve1=((my_list[1][0]-my_list[0][0])**2+(my_list[1][1]-my_list[0][1])**2)**0.5
        distanve2=((my_list[2][0]-my_list[0][0])**2+(my_list[2][1]-my_list[0][1])**2)**0.5
        distance3=((my_list[1][0]-my_list[2][0])**2+(my_list[1][1]-my_list[2][1])**2)**0.5
        min= distanve1
        for i in [distanve2,distance3]:
            if min>i:
                min=i
        return min
    if len(my_list)==2:
        distanve1=((my_list[1][0]-my_list[0][0])**2+(my_list[1][1]-my_list[0][1])**2)**0.5
        return distanve1
    ave=int(len(my_list)/2)
    a1=[]
    a2=[]
    for item in range(ave):

        a1.append(my_list[item])

    
    for item2 in range(ave,len(my_list)):

        a2.append(my_list[item2])
    d1=minimum_distance(a1)
    d2=minimum_distance(a2)
    d=0
    if d1>=d2:
        d=d2
    else :
        d=d1
    min=my_list[ave][0]-d
    max=my_list[ave][0]+d
    new_list=[]
    for j in my_list:
        if(j[0]>min and j[0]<max):
            new_list.append(j)
    my_list=new_list
    
    minimum_d=minimum_distance_y(my_list,d)
    return minimum_d

if __name__ == '__main__':
    input = sys.stdin.read()
    data = list(map(int, input.split()))
    n = data[0]
    x = data[1::2]
    y = data[2::2]
    my_list=[]
    for i in range(n):
        my_list.append([x[i],y[i]])
    randomized_quick_sort(my_list, 0, len(my_list)-1,0)
    print("{0:.9f}".format(minimum_distance(my_list)))
# my_list=[]
# for i in range(100):
#     x=random.randint(-100,100)
#     y=random.randint(-100,100)
#     my_list.append([x,y])
# my_list=[[7,7],[1,100],[4,8],[9,7]]
# # # my_list=[[0,0],[5,6],[3,4],[7,2]]
# randomized_quick_sort(my_list, 0, len(my_list)-1,0)
# print(my_list)
# print(minimum_distance(my_list))
