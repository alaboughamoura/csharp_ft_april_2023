class Node {
    constructor(value){
        this.value = value
        this.next = null
        this.previous = null
    }
}

class DLL {
    constructor(){
        this.head = null
        this.tail = null
    }
    isEmpty(){
        return this.head === null
    }

    addToHead(value){
        let newNode = new Node(value)
        if(this.isEmpty()) {
            this.head = newNode
            this.tail = newNode
            return this
        }
        newNode.next = this.head
        this.head.previous = newNode
        this.head = newNode
        return this
    }
    
    addToTail(head){
        let newNode = new Node(value)
        if(this.isEmpty()) {
            this.head = newNode
            this.tail = newNode
            return this
        }
        // newNode.next = this.head
        // this.head.previous = newNode
        // this.head = newNode
        // return this
    }
}
node1 = new Node(5)
node2 = new Node(2)
node3 = new Node(11)
dll =new DLL()
// console.log("Node  = ", node1);
console.log("Double Linked List Empty= ", dll,"*********************");
dll.head = node1
dll.tail = node1
console.log("Double Linked List Before = ", dll,"*********************");
dll.addToHead(900)
console.log("Double Linked List After= ", dll);
// console.log("Double Linked List is Empty = ", dll.isEmpty());