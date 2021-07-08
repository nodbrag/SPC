<template>
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
            <el-input v-model="filter.productKeyword" placeholder="产品名或编号" @keyup.enter.native="search" size="mini"></el-input>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="search" >搜索</el-button>
            <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"  size="mini" @click="showAddDialog" >添加</el-button>
          </el-form>
        </div>
      </div>
      <!--列表-->
      <el-table class="tableCss" :data="datalist" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="productCode" label="产品编号" width="280" sortable>
        </el-table-column>
        <el-table-column prop="productName" label="产品名称"  sortable>
        </el-table-column>
        <el-table-column label="操作" width="180">
          <template slot-scope="scope">
            <el-button size="small" @click="showEditDialog(scope.row)">编辑</el-button>
            <el-button type="danger" @click="del(scope.row.productID)" size="small">删除</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!--工具条-->
      <el-col :span="24" class="toolbar">
        <Pagination
          @handleCurrentChange="handleCurrentChange"
          @handleSizeChange="maxResultCountSelect"
          :page-size="maxResultCount"
          :page-sizes="pageSelectList"
          :total="totalCount">
        </Pagination>
      </el-col>
      <!--新增界面-->
      <el-dialog  :visible.sync ="addFormVisible"  :before-close="closeAddDialog">
        <div slot="title">添加产品</div>
        <el-form :model="addForm" label-width="100px" :rules="editFormRules" ref="addForm">
          <el-form-item label="产品编号:" prop="productCode">
            <el-input v-model="addForm.productCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="产品名称:" prop="productName">
            <el-input v-model="addForm.productName" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="add" :loading="loading">保存</el-button>
        </div>
      </el-dialog>

      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">编辑产品</div>
        <el-form :model="editForm" label-width="100px" :rules="editFormRules" ref="editForm">
          <el-form-item label="产品编号:" prop="productCode">
            <el-input v-model="editForm.productCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="产品名称:" prop="productName">
            <el-input v-model="editForm.productName" auto-complete="off"></el-input>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeEditDialog">取消</el-button>
          <el-button type="primary" @click.native="edit">保存</el-button>
        </div>
      </el-dialog>
    </el-col>
  </el-row>
</template>
<script>
  import ProductView from '../../../View/ProductView';
  export default new ProductView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
