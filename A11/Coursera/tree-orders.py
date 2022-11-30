# python3

import sys
import threading
sys.setrecursionlimit(10**6)  # max depth of recursion
threading.stack_size(2**27)  # new thread will get stack of such size


class TreeOrders:
  def read(self):
    self.n = int(sys.stdin.readline())

    self.key = [0 for i in range(self.n)]
    self.left = [0 for i in range(self.n)]
    self.right = [0 for i in range(self.n)]
    # self.father = [-1 for i in range(self.n)]
    # self.root = -1
    for i in range(self.n):
      [a, b, c] = map(int, sys.stdin.readline().split())
      self.key[i] = a
      self.left[i] = b
      self.right[i] = c
      # if b != -1:
      #   self.father[b] = i
      # if c != -1:
      #   self.father[c] = i
    # self.root=find_root()
    # root = -1
    # currentfather = 1
    # while currentfather != -1:
    #   root = currentfather
    #   currentfather = self.father[currentfather]
    # self.root = root

  # def find_root(self):
    

  def inOrder(self, root):
    # Finish the implementation
    # You may need to add a new recursive method to do that
    if self.left[root] != -1:
      self.inOrder(self.left[root])
    print(self.key[root],end=" ")
    if self.right[root] != -1:
      self.inOrder(self.right[root])
    return

  def preOrder(self, root):
    # Finish the implementation
    # You may need to add a new recursive method to do that
    print(self.key[root],end=" ")
    if self.left[root] != -1:
      self.preOrder(self.left[root])
    if self.right[root] != -1:
      self.preOrder(self.right[root])
    return

  def postOrder(self, root):
    # Finish the implementation
    # You may need to add a new recursive method to do that
    if self.left[root] != -1:
      self.postOrder(self.left[root])
    if self.right[root] != -1:
      self.postOrder(self.right[root])
    print(self.key[root],end=" ")
    return 


def main():
  tree = TreeOrders()
  tree.read()
  tree.inOrder(0)
  print()
  tree.preOrder(0)
  print()
  tree.postOrder(0)
  print()

threading.Thread(target=main).start()

