# python3

def siftdown(data,index):
    i=index
    swaps=[]
    while i<=int((len(data)-2)/2):
        min=i
        if len(data)-1>=i*2+1:
            if data[min]>data[2*i+1]:
                min=2*i+1
        if len(data)-1>=i*2+2:
            if data[min]>data[2*i+2]:
                min=2*i+2
        if min!=i:
            swaps.append((i,min))
            data[i],data[min]=data[min],data[i]
            i=min
            continue
        break
    return swaps

def build_heap(data):
    """Build a heap from ``data`` inplace.

    Returns a sequence of swaps performed by the algorithm.
    """
    # The following naive implementation just sorts the given sequence
    # using selection sort algorithm and saves the resulting sequence
    # of swaps. This turns the given array into a heap, but in the worst
    # case gives a quadratic number of swaps.
    #
    # TODO: replace by a more efficient implementation
    # swaps = []
    # for i in range(len(data)):
    #     for j in range(i + 1, len(data)):
    #         if data[i] > data[j]:
    #             swaps.append((i, j))
    #             data[i], data[j] = data[j], data[i]
    # return swaps
    # -----------------------------------------------------------------------
    swaps=[]
    i=int((len(data)-2)/2)
    while i>=0:
        swaps+=siftdown(data,i)
        i-=1
    # for i in range(int((len(data)-1)/2)-1,-1,-1):
    #     swaps+=siftdown(data,i)
    return swaps


def main():
    n = int(input())
    data = list(map(int, input().split()))
    assert len(data) == n

    swaps = build_heap(data)

    print(len(swaps))
    for i, j in swaps:
        print(i, j)


if __name__ == "__main__":
    main()
    # build_heap([5,4,3,2,1])
