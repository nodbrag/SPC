<template>
    <el-steps :space="60" :active="progress">
        <el-step icon="iconbianzu iconfont"></el-step>
        <el-step icon="iconbianzu1 iconfont"></el-step>
        <el-step icon="iconbianzu2 iconfont"></el-step>
        <el-step icon="iconbianzu3 iconfont"></el-step>
        <el-step icon="iconbianzu4 iconfont"></el-step>
        <el-step icon="iconbianzu5 iconfont"></el-step>
    </el-steps>
</template>

<script>
export default {
    props:{
        progress:Number
    }
}
</script>
<style lang="stylus" scope>
.el-step__icon-inner
    font-weight normal
    line-height 40px
    font-size 35px
.el-step.is-horizontal .el-step__line
    top 20px
.el-step__icon.is-icon
    height 44px
    width 36px
    border-radius 50%
.el-step__head.is-finish
    color #007AFF
.el-step__head.is-process
    color #D8D8D8
.el-step__head.is-wait
    color #D8D8D8
</style>
