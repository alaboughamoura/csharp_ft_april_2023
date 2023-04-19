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
    contains(value){
        if(this.iSEmpty()){
            return false
        }
        let runner = this.root
        while(runner){
            if(runner.value === value){
                return true
            }else{
                if(runner.value>value){
                    runner = runner.left
                }
                else{
                    runner = runner.right
                }
            }
        }
        return false
    }
    insert(value){
        let newNode = new Node(value)
        if(this.iSEmpty()){
            this.root = newNode
            return this
        }
        let runner = this.root;
        while(runner){
            if(runner.value<=value){
                if(runner.right === null){
                    runner.right = newNode
                    return this
                }
                runner = runner.right
            }else{
                if(runner.left === null){
                    runner.left = newNode
                    return this
                }
                runner  = runner.left;
            }
        }
    }
    removeMinValue(){
        if(this.iSEmpty()){
            return false
        }else{
            let runner  = this.root
            while(runner.left){
                if (runner.left.left === null){
                    runner.left = null
                    return this
                }else{
                    runner = runner.left
                }
            }
        }
    }
    removeMaxValue(){
        if(this.iSEmpty()){
            return false
        }else{
            let runner  = this.root
            while(runner.right){
                if (runner.right.right === null){
                    runner.right = null
                    return this
                }else{
                    runner = runner.right
                }
            }
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
// console.log(`Min Value = ${bst.min()}\nMax Value = ${bst.max()}`);
// console.log("Contains " , bst.contains(0));
bst.insert(3);
// console.log("Contains Before" , bst.contains(7));
bst.insert(7);
// console.log(bst);
// console.log(bst.min());
// console.log("Contains After" , bst.contains(7));
console.log("Minimum Before Delete:" , bst.min() );
bst.removeMinValue()
console.log("Minimum After Delete:" , bst.min() );
console.log("*************+********");
console.log("Maximum Before Delete:" , bst.max() );
bst.removeMaxValue()
console.log("Maximum After Delete:" , bst.max() );

