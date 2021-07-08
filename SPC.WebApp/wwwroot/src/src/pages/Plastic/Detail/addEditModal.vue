<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加缺陷项':'编辑缺陷项'}}</div>
    <div>
      <el-form :label-position="labelPosition" label-width="110px">
        <el-form-item label="缺陷项编号:" size="small">
          <el-input v-model="formData.defectItemCode"></el-input>
        </el-form-item>
        <el-form-item label="缺陷项名称:" size="small">
          <el-input v-model="formData.defectItemName"></el-input>
        </el-form-item>
        <el-form-item label="缺陷项备注:" size="small">
          <el-input type="textarea" v-model="formData.memo"></el-input>
        </el-form-item>
      </el-form>
      <div class="sub-btn">
        <el-button @click="handleModal(true, addOrEdit)">保存</el-button>
      </div>
    </div>
  </el-dialog>
</template>
<script>
  export default {
    props: {
      visible: {
        type: Boolean,
        default: false
      },
      formData:Object,
      addOrEdit:Number
    },
    data() {
      return {
        labelPosition: 'left'
      };
    },
    methods: {
      // isOperate 代表确认还是取消, addOrEdit代表添加还是编辑
      handleModal(isOperate, addOrEdit) {
        this.$emit('handleModal',isOperate, addOrEdit)
        // this.$emit('update:visible', false); // 直接修改父组件的属性
      }
    }
  }
</script>