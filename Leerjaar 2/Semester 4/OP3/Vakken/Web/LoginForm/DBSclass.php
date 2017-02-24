<?php
    class dbs{
     private $server;
     private $user;
     private $pwd;
     private $database;

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

        public function login($username, $password){
            $sql = "select * from `users` where Username='$username'";
            $result = mysqli_query($this->conn, $sql);

            if ($rij = mysqli_fetch_array($result)) {
            
                if ($rij['Password']==$password) {
                    $_SESSION['userid'] = $rij['UserID'];
                    header("Location: LoggedIn.php");
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