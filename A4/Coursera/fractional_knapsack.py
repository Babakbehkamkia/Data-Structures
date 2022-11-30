# Uses python3
import sys

def get_optimal_value(capacity, weights, values,n):
    value = 0.
    # write your code here
    ratio=[]
    for i in range (n):
        ratio.append(values[i]/weights[i])
    while capacity>0 and len(ratio):
        item=ratio.index(max(ratio))
        limit=min(capacity,weights[item])
        capacity-=limit
        value+=limit*(values[item]/weights[item])
        values[item]-=limit*(values[item]/weights[item])
        weights[item]-=limit
        if weights[item]==0:
            ratio.remove(ratio[item])
            weights.remove(weights[item])
            values.remove(values[item])
        
        
        
    return round(value,5)


if __name__ == "__main__":
    data = list(map(int, sys.stdin.read().split()))
    n, capacity = data[0:2]
    values = data[2:(2 * n + 2):2]
    weights = data[3:(2 * n + 2):2]
    opt_value = get_optimal_value(capacity, weights, values,n)
    print("{:.10f}".format(opt_value))

# print(get_optimal_value(1000, [30], [500],1))
