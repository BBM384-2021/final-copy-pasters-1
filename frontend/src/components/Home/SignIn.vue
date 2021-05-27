<template>
    <body>
      <main>
        <div class="big-box">
            <a href="#" class="logo">Interest Club</a>
          <form class="login" action="#">
            <input type="email" class="email" placeholder="Email" />
            <input type="password" class="input" placeholder="Password"/>
            <button class="login">Log In</button>
            <hr class="hr-text" data-content="Or">
            <button class="facebook" ><img src="~@/assets/fb.jpeg" width="20" height="20" style="float:left">Continue with Facebook</button>
            <button class="google"><img src="~@/assets/google.jpeg" width="20" height="20" style="float:left">Continue with Google</button>
            <a class="forgot_password" href="#">Forgot password?</a>
          </form>
        </div>
        <div class="small-box">
           <p>Don't have an account? <a href="#" @click="()=>$router.push('/sign_up')"><Strong>Sign up</Strong></a></p>
        </div>
      </main>
    </body>
</template>

<script>
  
  export default {
  name: "SignIn",
    
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">  
@import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:wght@500&display=swap');
  *{
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'Alegreya Sans', sans-serif;
  }
  .logo{
    text-decoration: none;
    font-weight: 800;
    color: #742957;
    font-size: 1.8em;
    margin:1em;
    display: flex;
    justify-content: center;
  }
  .big-box{
    background: #f5e2ee;
    margin:5%;
    border-radius: 2em;
    border: 0.2em solid rgb(245, 219, 227);
  }
  .small-box{
    margin-bottom: 25%;
    background: #f5e2ee;
    border-radius: 2em;
    margin-right: 5%;
    margin-left: 5%;
    border: 0.2em solid rgb(245, 219, 227);
    display:flex;
    justify-content: center;
    align-items: center;
    p{
      text-align: center;
      color: black;
      font-size: 125%;
      
      a{
        color:#865a9b;
        font-size: 100%;
      }
    }
  }
  main{
    height: 100vh;
    display: grid;
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-rows:3fr 1fr;
    grid-template-areas:". big-box ."
    ". small-box ." ;
  }
  .small-box {
    grid-area: small-box ;
  }
  .big-box{
    grid-area: big-box;
  }

  form{
    position:relative;
    top: 0;
    display: flex;
    align-items: center;
    justify-content: space-around;
    flex-direction: column;
    text-align: center;
    
    input{
      
      padding: 2% 3%;
      border-radius: 5em;
      border: 0.1em solid gray;
      width: 60%;
      margin: 1%;
      overflow: hidden;
      &:focus{
        outline: none;
        
      }
      
    }
  }
  .hr-text {
    margin-top: 5%;
    line-height: 1em;
    position: relative;
    outline: 0;
    border: 0;
    color: black;
    text-align: center;
    height: 1.5em;
    width: 50%;
    opacity: .5;

    &:before {
      content: '';
      background: black;
      position: absolute;
      left: 0;
      top: 50%;
      width: 100%;
      height: 5%;
    }
    &:after {
      content: attr(data-content);
      position: relative;
      display: inline-block;
      color: black;
      padding: 0 .5em;
      line-height: 1.5em;
      // this is really the only tricky part, you need to specify the background color of the container element...
      color: #252525;
      background-color: #f5e7f3;
    }
  }
  button.facebook{
    border-radius: 2em;
    border:0.1em solid #000000;
    background-color: #ffffff;
    color:gray;
    font-size: 1rem;
    padding: 2% 3%;
    letter-spacing: 0.1em;
    border-radius: 5em;
    font-weight: bold;
    width: 60%;  
    margin: 3%;
    margin-top: 6%;
    overflow: hidden;
    font-family: Alegreya Sans;
    &:active{
      transform: scale(.9);
    }
    &:focus{
      outline: none;
    }
  }
  button.google{
    border-radius: 2em;
    border:0.1em solid #000000;
    background-color: #ffffff;
    color:gray;
    font-size: 1rem;
    padding: 2% 3%;
    font-weight: bold;
    letter-spacing: 0.1em;
    border-radius: 5em;
    width: 60%;  
    overflow: hidden;
    &:active{
      transform: scale(.9);
    }
    &:focus{
      outline: none;
    }
  }
  button.login{
    border-radius: 2em;
    border:0.1em solid #000000;
    background-color: #742957b6;
    color: #ffff;
    font-size: 1rem;
    font-weight: bold;
    width: 60%;  
    padding: 2% 3%;
    margin-top: 3%;
    letter-spacing: 0.1em;
    &:active{
      transform: scale(.9);
    }
    &:focus{
      outline: none;
    }
  }
  .forgot_password{
      text-decoration: none;
      color:black;
      margin-top: 1em;
  }
  @media screen and (max-width:1000px){
    button.google, button.facebook{ 
       font-size: 0.6rem;
    }
  }
</style>