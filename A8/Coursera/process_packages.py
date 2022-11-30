# python3

from collections import namedtuple

Request = namedtuple("Request", ["arrived_at", "time_to_process"])
Response = namedtuple("Response", ["was_dropped", "started_at"])


class Buffer:
    def __init__(self, size):
        self.size = size
        self.finish_time = []

    def process(self, request):
        # write your code here
        s=request.arrived_at
        t=request.time_to_process
        # if len(self.finish_time)<self.size:
        #     self.finish_time.append(s+t)
        #     return Response(False,s)
        if len(self.finish_time):
            max_item=self.finish_time[-1]
            M=max(s,max_item)
            
            if len(self.finish_time)<self.size:
                self.finish_time.append(M+t)
                return Response(False,M)
            min_item=min(self.finish_time)
            if s>=min_item:
                
                self.finish_time.remove(min_item)
                self.finish_time.append(M+t)
                return Response(False,M)
            else:
                return Response(True,-1)
        else:
            self.finish_time.append(s+t)
            return Response(False,s)


def process_requests(requests, buffer):
    responses = []
    for request in requests:
        responses.append(buffer.process(request))
    return responses


def main():
    buffer_size, n_requests = map(int, input().split())
    requests = []
    for _ in range(n_requests):
        arrived_at, time_to_process = map(int, input().split())
        requests.append(Request(arrived_at, time_to_process))

    buffer = Buffer(buffer_size)
    responses = process_requests(requests, buffer)

    for response in responses:
        print(response.started_at if not response.was_dropped else -1)


if __name__ == "__main__":
    main()
    # buffer = Buffer(1)
    # responses = process_requests([(0,0)], buffer)
