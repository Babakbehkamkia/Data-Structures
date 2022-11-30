# Uses python3
def evalt(a, b, op):
    if op == '+':
        return a + b
    elif op == '-':
        return a - b
    elif op == '*':
        return a * b
    else:
        assert False

def Min_and_Max(x,y,d_min,d_max,dataset):
    minimum=9999
    maximum=-9999
    for m in range(x,y):
        n=((m-1)*2)+1
        a=evalt(d_min[x][m],d_min[m+1][y],dataset[n])
        b=evalt(d_min[x][m],d_max[m+1][y],dataset[n])
        c=evalt(d_max[x][m],d_min[m+1][y],dataset[n])
        d=evalt(d_max[x][m],d_max[m+1][y],dataset[n])
        minimum=min(minimum,a,b,c,d)
        maximum=max(maximum,a,b,c,d)
    return minimum,maximum
def get_maximum_value(dataset):
    #write your code here
    # creating a 2D array
    n=len(dataset)
    d_min=[]
    d_max=[]
    numbers=[]
    k=0
    while k<len(dataset):
        numbers.append(int(dataset[k]))
        k+=2

    for i in range(int((n+1)/2)+1):
        d_insert=[]
        for j in range(int((n+1)/2)+1):
            if i==j and i!=0:
                d_insert.append(numbers[i-1])
            else:
                d_insert.append(0)
        d_min.append(d_insert)
        

    for i in range(int((n+1)/2)+1):
        d_insert=[]
        for j in range(int((n+1)/2)+1):
            if i==j and i!=0:
                d_insert.append(numbers[i-1])
            else:
                d_insert.append(0)
        d_max.append(d_insert)




    for z in range(1,len(numbers)):
        for x in range(1,len(numbers)+1-z):
            y=x+z
            a1,a2=Min_and_Max(x,y,d_min,d_max,dataset)
            d_min[x][y],d_max[x][y]=a1,a2

    return d_max[1][-1]


if __name__ == "__main__":
    print(get_maximum_value(input()))

# print(get_maximum_value(input()))
