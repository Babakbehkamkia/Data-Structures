#Uses python3

import sys

def lcs2(s, t):
    d=[]
    d_list=[]
    for k in range (len(t)+1):
        
        d_list.append(0)
    d.append(d_list)
    for i in range(1,len(s)+1):
        d_list=[0]
        for j in range(len(t)):
            d_list.append(0)
        d.append(d_list)
    for i in range(1,len(s)+1):
        for j in range(1,len(t)+1):
            insert=d[i-1][j]
            delete=d[i][j-1]
            match=d[i-1][j-1]+1
            dismatch=d[i-1][j-1]
            if s[i-1]==t[j-1]:
                d[i][j]=max(insert,delete,match)
            else:
                d[i][j]=max(insert,delete,dismatch)
    

    return d[len(s)][len(t)]
    #write your code here
    # return min(len(a), len(b))

# if __name__ == '__main__':
#     input = sys.stdin.read()
#     data = list(map(int, input.split()))

#     n = data[0]
#     data = data[1:]
#     a = data[:n]

#     data = data[n:]
#     m = data[0]
#     data = data[1:]
#     b = data[:m]

#     print(lcs2(a, b))

print(lcs2([2,7,8,3], [5,2,8,7]))
