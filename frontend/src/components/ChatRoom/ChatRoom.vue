<template>
    <div>
        <div class="message-container column">
                <div class="list-messages">
                    <div class="scroll" id="container">
                        <div class="messages">
                            <messaging
                            v-for="(message,i) in conversationsa"
                            v-bind:key="i"
                            :user="message.user"
                            :content="message.content"
                            :time="message.time"
                            :verde="message.verde"

                            />  
                        </div>
                    </div>
                </div>
                <div class="write-message list-messages ">
                    <div class="icon-area">
                        <input v-model="messageSend"  v-on:keyup.enter="sendMessage" type="text" class="input" placeholder="Type a message">
                            <i   @click="sendMessage" class='fa fa-paper-plane send-icon' style='font-size:20px;color:white'></i> 
                    </div>
                </div>
            </div>
    </div>
    
</template>

<script>
import conversations from "../store/ChatRoomData.js";
import messaging from "../components/ChatRoom/ChatRoomActiveMessage.vue";
    export default {
        components : {
            messaging, 
       },
       data: function(){
            return{
                conversationsa:conversations,
                messageSend: "",
                current_username:"Copy Paster",
        }
    },  methods:{
            sendMessage: function(){
                
            let currentTime = new Date().getHours() + ":" + new Date().getMinutes();
            let newMessage = {
                user:this.current_username,
                time: currentTime,
                content: this.messageSend,
                verde: true
            };
            if(newMessage.content!=""){
                this.conversationsa
                .push(newMessage);
                this.messageSend = "";
                this.scrollToEnd();
            }
           
            },
            scrollToEnd: function() {    	
                var container = this.$el.querySelector("#container");
                container.scrollTop = container.scrollHeight;
            },
            
        }
    }
</script>


<style scoped lang="scss">
     @import url('https://fonts.googleapis.com/css2?family=Alegreya+Sans:wght@500&display=swap');
    * {
      font-family:'Alegreya Sans', sans-serif;
    }
    .column{
        height: 500px;
        border-radius: 5px;
        border : 1px solid #a56a9d;
        padding: 5px;
        
    }

    .conversation-list-container{
        width: 40% ;
        background: white;
        border : 1px solid #a56a9d;
        padding:5px;
       
    }

    .message-container{
        width: 60% ;
        background: #f0f0f0;
        display: flex;
        flex-direction: column;
    }
  
    .list-messages{
        height: 85%;
        display: flex;
        flex-direction: column;
       
        
    }

    .write-message{
        height: 37px;
        bottom:35px;
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
         margin-bottom: 5px;
        
    }
    .scroll{
        overflow-y: auto;
    }
</style>
