<template>
    <div class="message-con" v-bind:class="{verde: verde}">
        {{content}}
        <span> {{time}}</span>

        
    </div>
</template>

<script>
export default {
    props:['time','content','verde']
}
</script>

<style >
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
    .message-con span{
    margin-left: 25px;
    font-size: 11px;
    color: gray;
}
</style>