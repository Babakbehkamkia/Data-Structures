# Uses python3
import sys
import itertools

# def partition3(A):
#     for c in itertools.product(range(3), repeat=len(A)):
#         sums = [None] * 3
#         for i in range(3):
#             sums[i] = sum(A[k] for k in range(len(A)) if c[k] == i)

#         if sums[0] == sums[1] and sums[1] == sums[2]:
#             return 1

#     return 0


def deletion(used_items,d,col):
    current=len(d)-1
    d[current][col]-=1
    for i in range(1,1+len(used_items)):
        if current==0:
            break
        if current-used_items[-i]>=0 and d[current-used_items[-i]][col]>0:
            d[current-used_items[-i]][col]-=1
            current-=used_items[-i]
            used_items.remove(used_items[-i])
        

def partition3(A):
    count=0
    d=[]
    s=sum(A)
    if s%3!=0:
        return 0
    else:
        s=int(s/3)
    for i in range(s+1):
        d_insert=[]
        for j in range(len(A)):
            d_insert.append(0)
        d.append(d_insert)
    used_items=[]
    for i in range(len(A)):
        for j in range(s+1):
            for k in range(i):
                if d[j][k]>0 and j+A[i]<=s:
                    d[j+A[i]][i]+=1
            if j==0:
                d[A[i]][i]+=1
        used_items.append(A[i])
        if d[s][i]>0:
            count+=1
            if count==2:
                return 1
            deletion(used_items,d,i)
    return 0
        
        
    

    

# if __name__ == '__main__':
#     input = sys.stdin.read()
#     n, *A = list(map(int, input.split()))
#     print(partition3(A))
print(partition3([17 ,59, 34 ,57 ,17 ,23 ,67 ,1 ,18 ,2 ,59]))

