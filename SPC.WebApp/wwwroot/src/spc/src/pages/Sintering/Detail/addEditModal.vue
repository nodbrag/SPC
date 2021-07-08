<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加':'编辑'}}</div>
    <div>
      <el-form :label-position="labelPosition" label-width="80px">
        <el-form-item label="批号C:" size="small">
          <el-input v-model="formData.batchC"></el-input>
        </el-form-item>
        <el-form-item label="产品名称:" size="small">
          <el-input v-model="formData.productName"></el-input>
        </el-form-item>
        <el-form-item label="炉号:" size="small">
          <el-input v-model="formData.furnaceNumber"></el-input>
        </el-form-item>
        <el-form-item label="产品数量:" size="small">
          <el-input v-model="formData.productQuantity"></el-input>
        </el-form-item>
        <el-form-item label="烧结时间:" size="small">
          <el-input v-model="formData.sinteringTime"></el-input>
        </el-form-item>
        <el-form-item label="烧结盒:" size="small">
          <el-input v-model="formData.sinteringBox"></el-input>
        </el-form-item>
      </el-form>
    </div>
    <div slot="footer" class="detail-wrap-bottom">
      <el-button type="default" @click="handleModal(false, addOrEdit)">取消</el-button>
      <el-button type="primary" @click="handleModal(true, addOrEdit)">确认</el-button>
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