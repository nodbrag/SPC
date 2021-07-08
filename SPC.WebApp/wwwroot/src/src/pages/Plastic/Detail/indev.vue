<template>
  <!--<div>
     <div class="box_table">
         <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
             <el-form-item slot="input">
                 <el-input
                           size="mini"
                           placeholder=""
                           v-model="formSearch.defectItemName">
                 </el-input>
             </el-form-item>
             <div slot="addModal" class="box_add">
                 <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="addModal">添加</el-button>
             </div>
         </TableToolBar>
         <el-table
             :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
             :default-sort = "{prop: 'number', order: 'descending'}"
             stripe
             style="width: 100%">
             <el-table-column
             label="缺陷项编号"
             prop="defectItemCode">
             </el-table-column>
             <el-table-column
             label="缺陷项名称"
             prop="defectItemName">
             </el-table-column>
             <el-table-column
             label="缺陷项备注"
             prop="memo">
             </el-table-column>
             <el-table-column
             label="操作">
                 <template slot-scope="scope">
                     <el-dropdown>
                         <span class="el-dropdown-link">
                             <i class="el-icon-caret-bottom el-icon--right"></i>   详细
                         </span>
                         <el-dropdown-menu slot="dropdown">
                             <el-dropdown-item><span @click="handleEdit(scope.$index, scope.row)">编辑</span></el-dropdown-item>
                             <el-dropdown-item><span  @click="handleDelete(scope.$index, scope.row)">删除</span></el-dropdown-item>
                         </el-dropdown-menu>
                     </el-dropdown>
                 </template>
             </el-table-column>
         </el-table>
         <Pagination></Pagination>
     </div>

     <addEditModal v-show="addVisible" :visible.sync="addVisible" :addOrEdit="addOrEdit" :formData="addOrEdit===1?{}:formModal" @handleModal="handleModal(arguments)" />

     delete弹框
        <delModal v-show="delVisible" :visible.sync="delVisible" :rowId="rowId" @handleModalDel="handleModalDel(arguments)"></delModal>
    </div>-->
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
            <el-input v-model="filter.defectItemKeyword" placeholder="缺陷名或编号" @keyup.enter.native="search" size="mini"></el-input>
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
        <el-table-column prop="defectItemCode" label="缺陷编号" width="280" sortable>
        </el-table-column>
        <el-table-column prop="defectItemName" label="缺陷名称"  sortable>
        </el-table-column>
        <el-table-column prop="memo" label="备注"  sortable>
        </el-table-column>
        <el-table-column label="操作" width="180">
          <template slot-scope="scope">
            <el-button size="small" @click="showEditDialog(scope.row)">编辑</el-button>
            <el-button type="danger" @click="del(scope.row.defectItemID)" size="small">删除</el-button>
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
        <div slot="title">添加缺陷</div>
        <el-form :model="addForm" label-width="100px" :rules="editFormRules" ref="addForm">
          <el-form-item label="缺陷编号:" prop="defectItemCode">
            <el-input v-model="addForm.defectItemCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="缺陷名称:" prop="defectItemName">
            <el-input v-model="addForm.defectItemName" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="备注:" prop="memo">
            <el-input type="textarea" v-model="addForm.memo" auto-complete="off"></el-input>
          </el-form-item>

        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="add" :loading="loading">保存</el-button>
        </div>
      </el-dialog>

      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">编辑缺陷</div>
        <el-form :model="editForm" label-width="100px" :rules="editFormRules" ref="editForm">
          <el-form-item label="缺陷编号:" prop="defectItemCode">
            <el-input v-model="editForm.defectItemCode" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="缺陷名称:" prop="defectItemName">
            <el-input v-model="editForm.defectItemName" auto-complete="off"></el-input>
          </el-form-item>
          <el-form-item label="备注:" prop="memo">
            <el-input type="textarea" v-model="editForm.memo" auto-complete="off"></el-input>
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
  import DefectItemView from '../../../View/DefectItemView';
  export default new DefectItemView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
