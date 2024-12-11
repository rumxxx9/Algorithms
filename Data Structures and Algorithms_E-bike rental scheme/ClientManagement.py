class ClientNode:
    # Create ClientNode and set it into id, name, mobile and paymentMethod
    def __init__(self, cid, name, mobile, paymentMethod, nextNode = None):
        self.cid = cid
        self.name = name
        self.mobile = mobile
        self.paymentMethod = paymentMethod
        self.nextNode = nextNode

class ClientQueue:
    def __init__(self):
        # Initialise client list
        self.head = None
        self.last = None
        self.size = 0
        #test
        # self.enqueue("C1", "Amy", "0411 222 333", "Cash")
        # self.enqueue("C2", "Penny", "0422 333 444", "Debit cards")
        # self.enqueue("C3", "Jack", "0433 444 555", "Apple Pay")
    
    def isEmpty(self):
        # Check empty
        return self.head == None
    
    def enqueue(self, cid, name, mobile, paymentMethod):
        # Enqueue node to the linked list
        clients = ClientNode(cid, name, mobile, paymentMethod)
        if self.last is None:
            self.head = self.last = clients
            self.size += 1
            return
        self.last.nextNode = clients
        self.last = clients
        self.size += 1
    
    def dequeue(self):
        # Dequeue node from the linked list
        if self.isEmpty():
            return
        clients = self.head
        self.head = clients.nextNode
 
        if(self.head == None):
            self.last = None
        self.size -= 1
    
    def deleteClient(self, other):
        # Delete node from linked list by the input id
        if self.isEmpty():
            return
        clients = self.head
        preClient = clients
        curClient = clients.nextNode
        while(curClient != None):
            if curClient.cid == other:
                preClient.nextNode = curClient.nextNode
                curClient = preClient.nextNode
            else:
                preClient = preClient.nextNode
                curClient = curClient.nextNode
        self.size -= 1        
        return clients
    
    def checkID(self, other):
        # Check if the client id is in the list
        if self.isEmpty():
            return
        clients = self.head
        while (clients.cid != other):
            clients = clients.nextNode
            if clients is None:
                return None
        return -1
    
    def __len__(self):
        return self.size
    
    def displayClients(self):
        # Display client list
        clients = self.head
        print(f'Current number of the client is {self.size}\n')
        print("-----------------------------------\n")
        while (clients != None):
            print(f"      Client ID = {clients.cid}\n    Client Name = {clients.name}\n          Phone = {clients.mobile}\n Payment Method = {clients.paymentMethod}\n")
            clients = clients.nextNode
            print("-----------------------------------\n")