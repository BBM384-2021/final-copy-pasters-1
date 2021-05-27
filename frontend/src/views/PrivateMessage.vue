<template>
    <div>
        <clubheader></clubheader>
        <div class="flex-body">
            <div class="conversation-list-container column" >
                <div class="user">
                
                </div>
                <div class="user-list" v-for="(conversation,index) in conversationsa" :key=index>
                    <div class="item" @click="activeIndex=index">
                        <div class="title">
                            <img class="image" :src="require('@/assets/profile-photos/' + conversation.user + '.png')">
                            <p class="title-text"> {{conversation.user}}</p>
                        </div>
                      
                    </div>
                </div>
            </div>
            <div class="vl"></div>
            <div class="message-container column">
                <div class="user">
                    <div class="profile-image">
                    <img class="image" :src="require('@/assets/profile-photos/' + conversationsa[activeIndex].user + '.png')">
                    </div>
                    <span>{{conversationsa[activeIndex].user}}</span>
                </div>
                <div class="list-messages">
                    <div class="scroll">
                        <div class="messages">
                            <messaging
                            v-for="(message,i) in conversationsa[activeIndex].messages"
                            v-bind:key="i"
                            :content="message.content"
                            :time="message.time"
                            :verde="message.verde"
                            />  
                        </div>
                    </div>
                </div>
                <div class="write-message list-messages ">
                    <div class="icon-area">
                        <input v-model="messageSend" v-on:keyup.enter="sendMessage" type="text" class="input" placeholder="Type a message">
                        <i   @click="sendMessage" class='fa fa-paper-plane send-icon' style='font-size:20px;color:white'></i> 

                    </div>
                </div>
            </div>
            
        </div>
    </div>
</template>

<script>
    import SubClubPageHeader from "../components/SubClubPage/SubClubPageHeader.vue";
    import conversations from "../store/ChatData.js";
    import messaging from "../components/PrivateMessage/ActiveMessage.vue";
    export default{
        components : {
            "clubheader" : SubClubPageHeader,
            messaging, 
       },
        data: function(){
            return{
                conversationsa:conversations,
                activeIndex:0,
                messageSend: "",
        }
       
    },  methods:{
            sendMessage: function(){
                
            let currentTime = new Date().getHours() + ":" + new Date().getMinutes();
            let newMessage = {
                time: currentTime,
                content: this.messageSend,
                verde: true
            };
            if(newMessage.content!=""){
                 this.conversationsa[this.activeIndex]
                .messages
                .push(newMessage);
                this.messageSend = "";
            }
           
            }
            
        }
    }
</script>

<style scoped lang="scss">
     @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:wght@500&display=swap');
    * {
      font-family:'Alegreya Sans', sans-serif;
    }
    .flex-body{
        padding: 2%;
        display: flex;
        flex-direction: row;
        background: white;;
       
        
    }
    .column{
        height: 600px;
        border-radius: 5px;
        border : 1px solid #a56a9d;
        padding: 5px;
        
    }

    .conversation-list-container{
        width: 40% ;
        background: white;
        border : 1px solid #a56a9d;
        padding:5px
    }

    .message-container{
        width: 60% ;
        background: #f0f0f0;
        display: flex;
       // justify-content: flex-end;
        flex-direction: column;
    }
    .user{
        padding: 10px;
        border-radius:5px;
        height: 70px;
        background: #a56a9d;
        border-right: 1px solid rgb(200, 200, 200);
        border-bottom: 1px solid rgb(200, 200, 200);
        display: flex;
        flex-direction: row;

    }
    .user span{
        margin-top: 10px;
        line-height: 50px;
        margin-left: 10px;
        font-weight: 500;
        color: white;
        font-weight:bold;
        font-size: 30px;
    }
    .user-list{
       padding: 5px;
    }
    .item{
        background: white;
        padding: 15px 30px;
        border: 1px solid #a56a9d;
        border-radius: 5px;
      
    }
    .title{
        display: flex;
        flex-direction: row;
    }
    .subtitle{
        color:gray;
    }


    .item:hover{
        background:#f0f0f0;
        cursor: pointer;
    }

    .title-text{
        margin-left: 10px;
        font-size: 20px;
        font-weight:bold;
    }

    .subtitle-text{
        font-size: 15px;
        color: gray;
    }
    .vl {
        margin-top: 70px;
        border-left: 10px solid white;
        height: 855px;
    }   
     
    .list-messages{
        height: 75%;
        display: flex;
       // justify-content: flex-end;
        flex-direction: column;
    }

    .write-message{
        margin: 5px;
        height: 37px;
        bottom:100px;
        padding: 10px;
        border-radius:5px ;
        background: #a56a9d;
        

    }
    .write-message input{
        border:none;
        width: 93%;
        padding: 10px;
        border-radius: 15px;
        font-size: 15px;
        font-family: 'Alegreya Sans', sans-serif;
    }

   
    .image{
        margin-top: 10px;
        width: 50px;
        height: 50px;
        border-radius: 50px;
    }
    .icon-area{
        display: flex;
        flex-direction: row;
    }
    .send-icon{
        margin-left: 15px;
        margin-top:8px;
        border-radius: 50px;
    }
    .messages{
        height: 85%;
        display: flex;
        flex-direction: column;
     
        
    }
    .scroll{
        overflow-y: auto;
    }
</style>
