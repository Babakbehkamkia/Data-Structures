# Uses python3
import sys

def optimal_sequence(m):
    sequence = []
    d=[]
    for i in range(m+1):
        d.append(0)
    n=1
    while n<=m:
        first=d[n-1]+1
        third =first
        if n%3==0:
            third=d[int(n/3)]+1
        second=first
        if n%2==0:
            second=d[int(n/2)]+1
        
        d[n]=min(first,second,third)
        n+=1
    n-=1
    while n>1:
        sequence.append(n)
        first=d[n-1]
        second=first
        third=first
        if n%2==0:
            second=d[int(n/2)]
        if n%3==0:
            third=d[int(n/3)]
        m=min(first,second,third)
        if m==first:
            n-=1
        elif m==second:
            n=int(n/2)
        else:
            n=int(n/3)

    sequence.append(1)
    return sequence

input = sys.stdin.read()
n = int(input)

sequence = optimal_sequence(n)

# m,sequence = list(optimal_sequence(n))
# sequence=sequence.split(",")
sequence.reverse()
# print(len(sequence) )
# for j in range(len(sequence)):
#     print(sequence[j], end=' ')
print(len(sequence) - 1)
for x in sequence:
    print(x, end=' ')
