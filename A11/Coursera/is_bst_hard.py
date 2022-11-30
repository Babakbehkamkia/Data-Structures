import sys, threading
import queue
sys.setrecursionlimit(10**7) # max depth of recursion
threading.stack_size(2**25)  # new thread will get stack of such size


class Node:
    def __init__(self, a, b, c):
        self.key = a
        self.left = b
        self.right = c

def IsBinarySearchTree(tree):
    q=queue.Queue()

    q.put([float('-inf'), tree[0], float('inf')])
    while not q.empty():
        left,root,right= q.get()
        if root.key < left or root.key >= right:
            return False
        if root.left != -1:
            q.put([left, tree[root.left], root.key])
        if root.right != -1:
            q.put([root.key, tree[root.right], right])
    return True


def main():
    n_nodes = int(input())
    nodes = [0 for _ in range(n_nodes)]
    for i in range(n_nodes):
        a, b, c = map(int, input().split())
        node = Node(a, b, c)
        nodes[i] = node
    if n_nodes == 0 or IsBinarySearchTree(nodes):
        print('CORRECT')
    else:
        print('INCORRECT')


threading.Thread(target=main).start()