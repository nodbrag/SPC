<template>
    <el-dialog
        title="提示"
        :visible.sync="visible"
        :rowId="rowId"
        width="30%"
        :before-close="handleModalDel">
        <span>确认删除吗?</span>
        <span slot="footer" class="dialog-footer">
            <el-button @click="handleModalDel(false)">取 消</el-button>
            <el-button type="primary" @click="handleModalDel(true)">确 定</el-button>
        </span>
    </el-dialog>
</template>

<script>
  export default {
    props:{
        visible:{
            type: Boolean,
            default: false
        },
        rowId:{
            type: Number,
            default: 0
        }
    },
    methods: {
      handleModalDel(isdel) {
        this.$emit('handleModalDel',isdel)
        /* this.$emit('update:visible', false) // 直接修改父组件的属性 */
      },
    }
  };
</script>
