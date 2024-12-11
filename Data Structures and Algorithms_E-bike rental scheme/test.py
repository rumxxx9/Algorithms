from BikeManagement import BikeQueue

import time

b = BikeQueue()

print("Enqueue")
def func1():
    i = 0
    while i < 10:
        b.enqueue("B", "Available")
        i += 1
    print("10")
t = time.time()
func1()
print(f'cost: {time.time() - t:.8f}s')

def func2():
    i = 0
    while i < 100:
        b.enqueue("B", "Available")
        i += 1
    print("100")
t = time.time()
func2()
print(f'cost: {time.time() - t:.8f}s')

def func3():
    i = 0
    while i < 1000:
        b.enqueue("B", "Available")
        i += 1
    print("1000")
t = time.time()
func3()
print(f'cost: {time.time() - t:.8f}s')

def func4():
    i = 0
    while i < 10000:
        b.enqueue("B", "Available")
        i += 1
    print("10000")
t = time.time()
func4()
print(f'cost: {time.time() - t:.8f}s')

def func5():
    i = 0
    while i < 100000:
        b.enqueue("B", "Available")
        i += 1
    print("100000")
t = time.time()
func5()
print(f'cost: {time.time() - t:.8f}s')

def func6():
    i = 0
    while i < 1000000:
        b.enqueue("B", "Available")
        i += 1
    print("1000000")
t = time.time()
func6()
print(f'cost: {time.time() - t:.8f}s')

    
print("\nDequeue")
def func1():
    i = 10
    while i != 0:
        b.dequeue()
        i -= 1
    print("10")
t = time.time()
func1()
print(f'cost: {time.time() - t:.8f}s')

def func2():
    i = 100
    while i != 0:
        b.dequeue()
        i -= 1
    print("100")
t = time.time()
func2()
print(f'cost: {time.time() - t:.8f}s')

def func3():
    i = 1000
    while i != 0:
        b.dequeue()
        i -= 1
    print("1000")
t = time.time()
func3()
print(f'cost: {time.time() - t:.8f}s')

def func4():
    i = 10000
    while i != 0:
        b.dequeue()
        i -= 1
    print("10000")
t = time.time()
func4()
print(f'cost: {time.time() - t:.8f}s')

def func5():
    i = 100000
    while i != 0:
        b.dequeue()
        i -= 1
    print("100000")
t = time.time()
func5()
print(f'cost: {time.time() - t:.8f}s')

def func6():
    i = 1000000
    while i != 0:
        b.dequeue()
        i -= 1
    print("1000000")
t = time.time()
func6()
print(f'cost: {time.time() - t:.8f}s')