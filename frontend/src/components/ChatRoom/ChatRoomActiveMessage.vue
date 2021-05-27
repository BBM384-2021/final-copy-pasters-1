<template>
    <div class="message-con" v-bind:class="{verde: verde}">
        <div class="message-item">
            <span class="username">{{user}}</span>
            <div>
                {{content}}
                <span class="time"> {{time}}</span>
            </div>
    </div>
        
    </div>
</template>

<script>
export default {
    props:['time','content','verde','user']
}
</script>

<style scoped lang="scss" >
    .verde{
    background: rgb(220, 248, 198)  !important;
    align-self: flex-end;
}
    .message-con{
    font-size: 14px;
    box-shadow: rgba(0, 0, 0, 0.13) 0px 1px 0.5px 0px;;
    background: white;
    margin: 10px 20px;
    padding: 5px 10px;
    border-radius: 5px;
    width: fit-content;
}

    .time{
    margin-left: 25px;
    font-size: 11px;
    color: gray;
}
    .username{
        margin-left:3px;
        font-weight:bold;
        color: black;
    }
    .message-item{
        display: flex;
        flex-direction: column;
    }

</style>