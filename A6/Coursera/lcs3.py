#Uses python3

import sys

# def find_path(s,t,d):
#     n=len(s)+1
#     m=len(t)+1
#     result=[]
#     while n>1 and m >1:
#         if s[n-2]==t[m-2]:
#             result.append(d[n-1][m-1])


# def lcs2(s, t):
#     d=[]
#     d_list=[]
#     for k in range (len(t)+1):
        
#         d_list.append(0)
#     d.append(d_list)
#     for i in range(1,len(s)+1):
#         d_list=[0]
#         for j in range(len(t)):
#             d_list.append(0)
#         d.append(d_list)
#     for i in range(1,len(s)+1):
#         for j in range(1,len(t)+1):
#             insert=d[i-1][j]
#             delete=d[i][j-1]
#             match=d[i-1][j-1]+1
#             dismatch=d[i-1][j-1]
#             if s[i-1]==t[j-1]:
#                 d[i][j]=max(insert,delete,match)
#             else:
#                 d[i][j]=max(insert,delete,dismatch)
    
#     results=find_path(s,t,d)
        



#     return d[len(s)][len(t)]




# def lcs3_old(a, b, c):
#     #write your code here
#     l,s=lcs2(a,b)
#     length,t=lcs2(s,c)
#     return length


def lcs3(a,b,c):
    d_third_D=[]
    for i in range(len(a)+1):
        d_second_D=[]
        for j in range(len(b)+1):
            d_first_D=[]
            for k in range(len(c)+1):
                d_first_D.append(0)
            d_second_D.append(d_first_D)
        d_third_D.append(d_second_D)
    
    for x in range(1,len(a)+1):
        for y in range(1,len(b)+1):
            for z in range(1,len(c)+1):
                node_match=d_third_D[x-1][y-1][z-1]+1
                node_dismatch=d_third_D[x-1][y-1][z-1]
                node1=d_third_D[x-1][y-1][z]
                node2=d_third_D[x-1][y][z-1]
                node3=d_third_D[x-1][y][z]
                node4=d_third_D[x][y-1][z-1]
                node5=d_third_D[x][y-1][z]
                node6=d_third_D[x][y][z-1]
                if a[x-1]==b[y-1]==c[z-1]: 
                    d_third_D[x][y][z]=max(node1,node2,node3,node4,node5,node6,node_match)
                else:
                    d_third_D[x][y][z]=max(node1,node2,node3,node4,node5,node6,node_dismatch)
    return d_third_D[-1][-1][-1]



if __name__ == '__main__':
    input = sys.stdin.read()
    data = list(map(int, input.split()))
    an = data[0]
    data = data[1:]
    a = data[:an]
    data = data[an:]
    bn = data[0]
    data = data[1:]
    b = data[:bn]
    data = data[bn:]
    cn = data[0]
    data = data[1:]
    c = data[:cn]
    print(lcs3(a, b, c))

# print(lcs3([8,3,2,1,7], [8,2,1,3,8,10,7], [6,8,3,1,4,7]))
