<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加工序':'编辑工序'}}</div>
    <div>
      <el-form :label-position="labelPosition" label-width="90px">
        <el-form-item label="工序编号:" size="small">
          <el-input v-model="formData.workProcessCode"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="工序名称:" size="small">
          <el-input v-model="formData.workProcessName"></el-input>
        </el-form-item><div class="red">*</div>
        <!-- <el-form-item label="设备分类:" size="small">
          <el-select v-model="formData.EquipmentType">
            <el-option v-for="item in equipmentTypeList" :key="item.equipmentTypeName" :value="item.equipmentTypeID" :label="item.equipmentTypeName"></el-option>
          </el-select>
        </el-form-item> 
        <el-form-item label="产品名称:" size="small">
          <el-select v-model="formData.ProductName">
            <el-option v-for="item in ProductList" :key="item.ProductName" :value="item.ProductName" :label="item.ProductName"></el-option>
          </el-select>
        </el-form-item>-->
        <el-form-item label="工序描述:" size="small">
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
        labelPosition: 'left',
        // equipmentTypeList:[{equipmentTypeID:'111',equipmentTypeName:'13'}],
        // ProductList:[{ProductName:'手机配件A'},{ProductName:'电脑硬件A'}],
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