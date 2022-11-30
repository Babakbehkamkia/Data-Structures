# python3

from collections import namedtuple

AssignedJob = namedtuple("AssignedJob", ["worker", "started_at"])

# def siftdown(my_tree):
#     i=0
#     while i<=(len(my_tree)-1)/2 :
#         if 2*i+2<len(my_tree):
#             if my_tree[i][1]>my_tree[2*i+1][1] or my_tree[i][1]>my_tree[2*i+2][1]:
#                 if my_tree[2*i+1][1]>my_tree[2*i+2][1]:
#                     my_tree[i],my_tree[2*i+2]=my_tree[2*i+2],my_tree[i]
#                     i=2*i+2
#                     continue
#                 # elif my_tree[2*i+1][1]==my_tree[2*i+2][1]:
#                 #     if 
#                 else:
#                     my_tree[i],my_tree[2*i+1]=my_tree[2*i+1],my_tree[i]
#                     i=2*i+1
#                     continue
#         elif 2*i+1<len(my_tree):
#             if my_tree[i][1]>my_tree[2*i+1][1]:
#                 my_tree[i],my_tree[2*i+1]=my_tree[2*i+1],my_tree[i]
#                 i=2*i+1
#                 continue
        
#         break
def siftdown(data):
    i=0
    # swaps=[]
    while i<=int((len(data)-2)/2):
        min=i
        if len(data)-1>=i*2+1:
            if data[min][1]>data[2*i+1][1]:
                min=2*i+1
            elif data[min][1]==data[2*i+1][1]:
                if data[min][0]>data[2*i+1][0]:
                    min=2*i+1
        if len(data)-1>=i*2+2:
            if data[min][1]>data[2*i+2][1]:
                min=2*i+2
            elif data[min][1]==data[2*i+2][1]:
                if data[min][0]>data[2*i+2][0]:
                    min=2*i+2
        if min!=i:
            # swaps.append((i,min))
            data[i],data[min]=data[min],data[i]
            i=min
            continue
        break
    return



def assign_jobs(n_workers, jobs):
    # TODO: replace this code with a faster algorithm.
    # result = []
    # next_free_time = [0] * n_workers
    # for job in jobs:
    #     next_worker = min(range(n_workers), key=lambda w: next_free_time[w])
    #     result.append(AssignedJob(next_worker, next_free_time[next_worker]))
    #     next_free_time[next_worker] += job

    # return result
    # ------------------------------------------------------------------------
    result=[]
    my_tree=[]
    for i in range(n_workers):
        my_tree.append([i,0])
    for job in jobs:
        result.append(AssignedJob(my_tree[0][0], my_tree[0][1]))
        my_tree[0][1]+=job
        siftdown(my_tree)
    return result


def main():
    n_workers, n_jobs = map(int, input().split())
    jobs = list(map(int, input().split()))
    assert len(jobs) == n_jobs

    assigned_jobs = assign_jobs(n_workers, jobs)

    for job in assigned_jobs:
        print(job.worker, job.started_at)


if __name__ == "__main__":
    main()
    # assign_jobs(4,[1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1])
