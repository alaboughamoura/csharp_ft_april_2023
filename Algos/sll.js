//  Singly Linked List

class Node {
    constructor(value) {
        // Attributes
        this.value = value
        this.next = null
    }
}
class SLL {
    constructor() {
        this.head = null
    }
    isEmpty() {
        if (this.head === null) {
            return true
        } else {
            return false
        }
    }
    addToFront(value) {
        let newNode = new Node(value)
        if (this.isEmpty() == true) {
            this.head = newNode
            return this
        } else {
            newNode.next = this.head
            this.head = newNode
            return this
        }
    }
    print() {
        if (this.isEmpty()) {
            return false
        } else {
            let runner = this.head
            while (runner) {
                console.log(runner.value);
                runner = runner.next
            }
        }
    }
    addToBack(value) {
        let newNode = new Node(value)
        if (this.isEmpty) {
            this.head = newNode
            return this
        } else {
            let runner = this.head
            while (runner.next !== null) {
                runner = runner.next
            }
            runner.next = newNode
            return this
        }
    }
    removeAtFront() {
        if (this.isEmpty()) {
            return false
        } else {
            this.head = this.head.next
            return this
        }
    }
    removeAtBack() {
        if (this.isEmpty()) {
            return false
        } else {
            let runner = this.head
            while (runner.next) {
                if (runner.next.next !== null) {
                    runner = runner.next
                }
                runner.next = null
                return this
            }
        }
    }
    size() {
        if (this.isEmpty()) {
            return false
        } else {
            let count = 1
            let runner = this.head
            while (runner !== null) {
                count++
                runner = runner.next
            }
            return count
        }
    }
    find(value) {
        if (this.isEmpty()) {
            return false
        } else {
            let runner = this.head
            while (runner) {
                if (runner.value === value) {
                    return true
                } else {
                    runner = runner.next
                }
            }
            return false
        }
    }
    delete(value) {
        if (this.isEmpty()) {
            return false
        } else {
            let runner = this.head
            while (runner.next) {
                if (runner.next.value == value) {
                    console.log(`runner : ${runner.value} , runner.next : ${runner.next.value} runner.next.next  : ${runner.next.next}`);
                    runner.next = runner.next.next
                    return this
                } else {
                    runner = runner.next
                }
            }
        }
    }
    reverse() {
    }
}
let nodeOne = new Node(5)
let nodeTwo = new Node(10)
let nodeThree = new Node(-2)
nodeOne.next = nodeTwo
nodeTwo.next = nodeThree
sll = new SLL()
// console.log("1", sll.isEmpty());
sll.head = nodeOne
// console.log("SLL before", sll);
sll2 = new SLL()
// sll2.addToFront(20)
// console.log(sll2);
// sll.addToFront(999)
// console.log("SLL Before", sll);
// sll.removeAtFront()
// console.log("SLL After", sll);
// sll.print()
// sll.addToBack(1000)
// sll.print()
// sll.removeAtBack()
// console.log("************************");
sll.print()
// console.log(sll.size())
// console.log(sll.find(0));
sll.delete(-2)
console.log("************************");
sll.print()