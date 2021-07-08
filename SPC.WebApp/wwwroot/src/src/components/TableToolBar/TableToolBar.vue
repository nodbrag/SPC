<template>
    <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="formData" :inline="true" class="demo-form-inline">
            <!-- <el-input v-model="formData.batch" size="mini" placeholder="批号搜索"></el-input> -->
            <slot name="starttime"></slot>
            <slot name="endtime"></slot>
            <slot name="equipmentType"></slot>
            <slot name="equipmentName"></slot>
            <slot name="input"></slot>
            <el-form-item>
              <el-button type="primary" size="mini">搜索</el-button>
            </el-form-item>
            <slot name="addModal"></slot>
            <slot name="import"></slot>
          </el-form>
        </div>
    </div>
</template>
<script>
export default {
    props:{
        formData:Object
    },
    created() {
        //输出
        // console.log(111);
    },
    methods: {
        addModal() {
            // 分发自定义事件(事件名: closeTip)
            this.$emit('addModal')
        },
        importModal(){
            this.$emit('importModal')
        }
    },
}
</script>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>
