# Uses python3
import sys
from collections import namedtuple

Segment = namedtuple('Segment', 'start end')

def optimal_points(segments):
    points = []
    while len(segments)>1:
        for i in range(len(segments)):
            if segments[0][1]>segments[i][1]:
                temp=segments[0]
                segments[0]=segments[i]
                segments[i]=temp
        points.append(segments[0][1])
        #write your code here
        new_segments=[]
        for s in segments:
            if s[0]>points[-1] :
                new_segments.append(s)
        segments=new_segments
    if len(segments):
        points.append(segments[0][1])
    return points

if __name__ == '__main__':
    input = sys.stdin.read()
    n, *data = map(int, input.split())
    segments = list(map(lambda x: Segment(x[0], x[1]), zip(data[::2], data[1::2])))
    points = optimal_points(segments)
    print(len(points))
    print(*points)



# print(optimal_points([[1,3],[2,5],[3,6],[4,6]]))