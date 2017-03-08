<?php
    class dbs{
     private $server;
     private $user;
     private $pwd;
     private $database;
     private $checkpassword;

     public $conn = null;

        public function __construct(){
            $this->getInfo();
            $this->connDBS();
        }

        public function getInfo(){
            $this->server = "localhost";
            $this->user = "root";
            $this->pwd = "";
            $this->database = "op3";
        }

        public function connDBS(){
            try{
                $this->conn = new mysqli($this->server, $this->user, $this->pwd, $this->database);
            }
            catch(Exception $e){
                echo 'Caught exception: ', $e->getMessage(), '/n';
            }
        } 

        public function roles(){
            $sql = "select * from roles";
            $result = mysqli_query($this->conn, $sql);
            while ($rij = mysqli_fetch_array($result)) {
                    echo "<option value='".$rij['id']."'>".$rij['Name']."</option>";
            }
        }

        public function getUser($userID){
            $sql = "select * from `users` where userID='$userID'";
            $result = mysqli_query($this->conn, $sql);
            
            if ($rij = mysqli_fetch_array($result)) {
                echo $rij["firstName"]." ".$rij["lastName"];
            }

        }

        public function login($username, $password){
            $sql = "select * from `users` where Username='$username'";
            $result = mysqli_query($this->conn, $sql);

            if ($rij = mysqli_fetch_array($result)) {
            
                $this->checkpassword=hash('sha256', $password.$rij["Salt"]);
                for($round = 0; $round < 65536; $round++){
                    $this->checkpassword = hash('sha256', $this->checkpassword.$rij["Salt"]);
                }

                if ($rij['Password']==$this->checkpassword) {
                    unset($rij['Salt']);
                    unset($rij['Password']);

                    $_SESSION['userid'] = $rij['UserID'];

                    header("Location: Dashboard.php");
                }

                else {
                    echo "You're password is wrong. Please try again!<br><br><br>";
                }
            }

            else {
                echo "You're username is wrong. Please try again!<br><br><br>";
            }
        }
    }
?>