<template>
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
           <!-- <el-input v-model="filter.productID" placeholder="产品" @keyup.enter.native="search" size="mini"></el-input>-->
            <el-select v-model="filter.productId"    placeholder="请选择产品">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
            <el-select v-model="filter.workProcessId"  placeholder="请选择工序">
              <el-option
                v-for="item in workProcessOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
           <!-- <el-input v-model="filter.workProcessID" placeholder="工序" @keyup.enter.native="search" size="mini"></el-input>-->
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
        <el-table-column prop="productName" label="产品名称" width="280" sortable>
        </el-table-column>
        <el-table-column prop="workProcessName" label="工序名称"  sortable>
        </el-table-column>
        <el-table-column prop="parameterName" label="参数名称"  sortable>
        </el-table-column>
        <el-table-column label="操作" width="180">
          <template slot-scope="scope">
            <el-button size="small" @click="showEditDialog(scope.row)">编辑</el-button>
            <el-button type="danger" @click="del(scope.row.inspectionParamId)" size="small">删除</el-button>
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
        <div slot="title">添加产品检测参数</div>
        <el-form :model="addForm" label-width="100px" :rules="editFormRules" ref="addForm">
          <el-form-item label="产品名称:" prop="productId">
            <el-select v-model="addForm.productId"  placeholder="请选择">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="工序名称:" prop="workProcessId">
            <el-select v-model="addForm.workProcessId"  placeholder="请选择">
              <el-option
                v-for="item in workProcessOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="参数名称:" prop="parameterId">
            <el-select v-model="addForm.parameterId"  placeholder="请选择">
              <el-option
                v-for="item in parameterOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
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
          <el-form-item label="产品名称:" prop="productId">
            <el-select v-model="editForm.productId"  placeholder="请选择">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="工序名称:" prop="workProcessId">
            <el-select v-model="editForm.workProcessId"  placeholder="请选择">
              <el-option
                v-for="item in workProcessOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="参数名称:" prop="parameterID">
            <el-select v-model="editForm.parameterId"  placeholder="请选择">
              <el-option
                v-for="item in parameterOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
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
  import InspectionParamView from '../../../View/InspectionParamView';
  export default new InspectionParamView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
