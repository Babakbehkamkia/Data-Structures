# python3

from collections import namedtuple

Bracket = namedtuple("Bracket", ["char", "position"])


def are_matching(left, right):
    return (left + right) in ["()", "[]", "{}"]


def find_mismatch(text):
    opening_brackets_stack = []
    for i, next in enumerate(text):
        if next in "([{":
            # Process opening bracket, write your code here
            opening_brackets_stack.append([i,next])

        if next in ")]}":
            # Process closing bracket, write your code here
            if len(opening_brackets_stack)==0:
                return i
            if are_matching(opening_brackets_stack[-1][1], next):
                rem=opening_brackets_stack.pop(-1)
            else:
                return i
    if len(opening_brackets_stack)!=0:
        return opening_brackets_stack[-1][0]
    return -1


def main():
    text = input()
    mismatch = find_mismatch(text)
    # Printing answer, write your code here
    if mismatch==-1:
        print("Success")
    else:
        print(mismatch+1)


if __name__ == "__main__":
    main()
