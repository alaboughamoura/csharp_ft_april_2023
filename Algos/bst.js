// Binary Search Tree

class Node {
    constructor (value){
        this.value = value;
        this.left = null;
        this.right = null;
    }
}

class BST {
    constructor(){
        this.root = null;
    }
    iSEmpty(){
        return this.root == null;
    }
    min(){
        if(this.iSEmpty()){
            return false
        }else{
            let minVal = this.root.value
            let runner = this.root
            while(runner.left){
                if (runner.left.value<minVal){
                    minVal = runner.left.value
                }
                runner = runner.left
            }
            return minVal
        }
    }
    max(){
        if(this.iSEmpty()){
            return false
        }else{
            let maxVal = this.root.value
            let runner = this.root
            while(runner.right){
                if (runner.right.value>maxVal){
                    maxVal = runner.right.value
                }
                runner = runner.right
            }
            return maxVal
        }
    }
}
nodeOne = new Node(10)
nodeTwo = new Node(5)
nodeThree = new Node(15)
nodeOne.left = nodeTwo
nodeOne.right = nodeThree
bst = new BST()
bst.root = nodeOne;
nodeFour = new Node(12)
nodeThree.left = nodeFour
nodeFive = new Node(20)
nodeThree.right = nodeFive
nodeSix = new Node(4)
nodeTwo.left = nodeSix
console.log(`Min Value = ${bst.min()}\nMax Value = ${bst.max()}` );