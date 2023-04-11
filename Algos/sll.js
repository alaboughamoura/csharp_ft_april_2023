//  Singly Linked List

class Node {
    constructor(value){
        // Attributes
        this.value = value
        this.next = null
    }
}
class SLL {
    constructor() {
        this.head = null
    }
    isEmpty(){
        if(this.head === null){
            return true
        }else{
            return false
        }
    }
    addToFront(value){
        let newNode  = new Node(value)
        if(this.isEmpty() == true){
            this.head = newNode
            return this
        } else{
            newNode.next = this.head
            this.head = newNode
            return this
        }
    }
}
let nodeOne  = new Node(5)
let nodeTwo  = new Node(10)
let nodeThree  = new Node(-2)
nodeOne.next = nodeTwo
nodeTwo.next = nodeThree
sll = new SLL()
// console.log("1", sll.isEmpty());
sll.head = nodeOne
console.log("SLL before", sll);
sll2 = new SLL()
sll2.addToFront(20)
// console.log(sll2);
sll.addToFront(999)
console.log("SLL after", sll);
