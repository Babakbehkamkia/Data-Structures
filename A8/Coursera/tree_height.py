# python3

import sys
import threading
# from queue import Queue


def compute_height(n, parents):
    nodes=[]
    root=0
    for i in range(n):
        nodes.append([])
    for child in range(n):
        if parents[child]!=-1:
            nodes[parents[child]].append(child)
        else:
            root=child
    sum=0
    # q=Queue()
    while len(nodes[root]):
        new_children=[]
        for j in nodes[root]:
            for k in nodes[j]:
                new_children.append(k)
        nodes[root]=new_children
        sum+=1

        
    return sum+1

# def compute_height(n, parents):
#     # Replace this code with a faster implementation
#     max_height = 0
#     for vertex in range(n):
#         height = 0
#         current = vertex
#         while current != -1:
#             height += 1
#             current = parents[current]
#         max_height = max(max_height, height)
#     return max_height


def main():
    n = int(input())
    parents = list(map(int, input().split()))
    print(compute_height(n, parents))


# # In Python, the default limit on recursion depth is rather low,
# # so raise it here for this problem. Note that to take advantage
# # of bigger stack, we have to launch the computation in a new thread.
# sys.setrecursionlimit(10**7)  # max depth of recursion
# threading.stack_size(2**27)   # new thread will get stack of such size
# threading.Thread(target=main).start()

# print(compute_height(5, [-1,0,4,0,3]))
main()