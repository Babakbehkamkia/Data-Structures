# Uses python3
import sys

def optimal_weight(W, w):
    # write your code here
    
    # creating a list to store data
    d=[]
    for i in range(len(w)+1):
        d_insert=[]
        for j in range (W+1):
            d_insert.append(0)
        d.append(d_insert)
    
    for x in range(1,len(w)+1):
        for y in range(1,W+1):
            a=d[x-1][y]
            b=a
            if y>=w[x-1]:
                b=d[x-1][y-w[x-1]]+w[x-1]
            
            d[x][y]=max(a,b)

    return d[len(w)][W]

if __name__ == '__main__':
    input = sys.stdin.read()
    W, n, *w = list(map(int, input.split()))
    print(optimal_weight(W, w))

# print(optimal_weight(10, [1,4,8]))
