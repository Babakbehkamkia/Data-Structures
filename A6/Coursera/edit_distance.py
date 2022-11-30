# Uses python3
def edit_distance(s, t):
    #write your code here
    d=[]
    d_list=[]
    for k in range (len(t)+1):
        
        d_list.append(k)
    d.append(d_list)
    for i in range(1,len(s)+1):
        d_list=[i]
        for j in range(len(t)):
            d_list.append(0)
        d.append(d_list)
    for i in range(1,len(s)+1):
        for j in range(1,len(t)+1):
            insert=d[i-1][j]+1
            delete=d[i][j-1]+1
            match=d[i-1][j-1]
            dismatch=d[i-1][j-1]+1
            if s[i-1]==t[j-1]:
                d[i][j]=min(insert,delete,match)
            else:
                d[i][j]=min(insert,delete,dismatch)
    

    return d[len(s)][len(t)]

if __name__ == "__main__":
    print(edit_distance(input(), input()))

# print(edit_distance("editing","distance"))
