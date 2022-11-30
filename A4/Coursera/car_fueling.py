# python3
import sys


def compute_min_refills(distance, tank, stops):

    # write your code here
    answer=0
    current=0
    stops.append(distance)
    while distance!=current:
        last=-1
        for i in range(len(stops)):
            if current+tank<stops[i]:
                break
            last=i
        if last==-1:
            answer=0
            break
        answer+=1
        current=stops[last]
        for i in range(last+1):
            stops.remove(stops[0])
            
    
    
    return answer-1

if __name__ == '__main__':
    d, m, _, *stops = map(int, sys.stdin.read().split())
    print(compute_min_refills(d, m, stops))


# print(compute_min_refills(10, 3, [1,2,5,9]))